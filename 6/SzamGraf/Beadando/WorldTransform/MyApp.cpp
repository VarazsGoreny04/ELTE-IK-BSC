#include "MyApp.h"
#include "SDL_GLDebugMessageCallback.h"

#include <imgui.h>

CMyApp::CMyApp()
{
}

CMyApp::~CMyApp()
{
	colors.clear();
	layouts.clear();
}

void CMyApp::SetupDebugCallback()
{
	GLint context_flags;
	glGetIntegerv(GL_CONTEXT_FLAGS, &context_flags);
	if (context_flags & GL_CONTEXT_FLAG_DEBUG_BIT) {
		glEnable(GL_DEBUG_OUTPUT);
		glEnable(GL_DEBUG_OUTPUT_SYNCHRONOUS);
		glDebugMessageControl(GL_DONT_CARE, GL_DONT_CARE, GL_DEBUG_SEVERITY_NOTIFICATION, 0, nullptr, GL_FALSE);
		glDebugMessageControl(GL_DONT_CARE, GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR, GL_DONT_CARE, 0, nullptr, GL_FALSE);
		glDebugMessageCallback(SDL_GLDebugMessageCallback, nullptr);
	}
}

void CMyApp::InitShaders()
{
	m_programID = glCreateProgram();
	AttachShader(m_programID, GL_VERTEX_SHADER, "Shaders/Vert_PosCol.vert");
	AttachShader(m_programID, GL_FRAGMENT_SHADER, "Shaders/Frag_PosCol.frag");
	LinkProgram(m_programID);
}

void CMyApp::CleanShaders() const
{
	glDeleteProgram(m_programID);
}

static std::vector<glm::vec3> BasePolygon(int sides, float scale)
{
	std::vector<glm::vec3> result;

	float temp, newX, newY;
	float converter = 360.f / sides * (M_PI / 180);

	for (int i = sides; i >= 1; --i)
	{
		temp = (i % sides) * converter;
		newX = cosf(temp) * scale;
		newY = sinf(temp) * scale;

		result.push_back(glm::vec3(newX, 0.f, newY));
	}

	return result;
}

void CMyApp::InitTriangleFan(std::vector<glm::vec3>& points, std::vector<int> indexesInvolved)
{
	GLuint vaoID = vaoIDs.size();
	GLuint vboID = vboIDs.size();
	GLuint iboID = iboIDs.size();
	GLsizei count = counts.size();

	MeshObject<VertexPosColor> meshCPU;

	static constexpr float SQRT_2 = glm::root_two<float>();

	for (int i = 0; i < indexesInvolved.size(); ++i)
		meshCPU.vertexArray.push_back({ points[indexesInvolved[i]], colors[indexesInvolved[i] % colors.size()] });
	meshCPU.vertexArray.push_back({ points[indexesInvolved[1]], colors[indexesInvolved[1] % colors.size()] });

	for (int i = 0; i < indexesInvolved.size(); ++i)
		meshCPU.indexArray.push_back(i);
	meshCPU.indexArray.push_back(1);

	glCreateBuffers(1, &vboID);

	glNamedBufferData(vboID, meshCPU.vertexArray.size() * sizeof(VertexPosColor), meshCPU.vertexArray.data(), GL_STATIC_DRAW);

	glCreateBuffers(1, &iboID);
	glNamedBufferData(iboID, meshCPU.indexArray.size() * sizeof(GLuint), meshCPU.indexArray.data(), GL_STATIC_DRAW);

	count = static_cast<GLsizei>(meshCPU.indexArray.size());

	glCreateVertexArrays(1, &vaoID);

	glVertexArrayVertexBuffer(vaoID, 0, vboID, 0, sizeof(VertexPosColor));

	glEnableVertexArrayAttrib(vaoID, 0);
	glVertexArrayAttribBinding(vaoID, 0, 0);
	glVertexArrayAttribFormat(vaoID, 0, 3, GL_FLOAT, GL_FALSE, offsetof(VertexPosColor, position));

	glEnableVertexArrayAttrib(vaoID, 1);
	glVertexArrayAttribBinding(vaoID, 1, 0);
	glVertexArrayAttribFormat(vaoID, 1, 3, GL_FLOAT, GL_FALSE, offsetof(VertexPosColor, color));

	glVertexArrayElementBuffer(vaoID, iboID);

	vaoIDs.push_back(vaoID);
	vboIDs.push_back(vboID);
	iboIDs.push_back(iboID);
	counts.push_back(count);
}

void CMyApp::InitGeometry()
{
	CleanGeometry();

	vaoIDs.clear();
	vboIDs.clear();
	iboIDs.clear();
	counts.clear();

	std::vector<glm::vec3> square = BasePolygon(sides, sqrtf(2) / 2);

	std::vector<glm::vec3> points;

	for (int i = 0; i < square.size(); ++i)
		points.push_back(glm::vec3(square[i].x, 0.5f, square[i].z));

	for (int i = 0; i < square.size(); ++i)
		points.push_back(glm::vec3(square[i].x, -0.5f, square[i].z));

	InitTriangleFan(points, { 0, 1, 2, 3, 7, 4, 5 });
	InitTriangleFan(points, { 6, 2, 1, 5, 4, 7, 3 });

	square.clear();
	points.clear();
}

void CMyApp::CleanGeometry()
{
	for (int i = vboIDs.size() - 1; i >= 0; --i)
	{
		glDeleteBuffers(1, &vboIDs[i]);
		glDeleteBuffers(1, &iboIDs[i]);
		glDeleteVertexArrays(1, &vaoIDs[i]);
	}
}

bool CMyApp::Init()
{
	SetupDebugCallback();

	glClearColor(0.125f, 0.25f, 0.5f, 1.0f);

	InitShaders();
	InitGeometry();

	glEnable(GL_CULL_FACE);
	glCullFace(GL_BACK);

	glEnable(GL_DEPTH_TEST);

	m_camera.SetView(
		glm::vec3(0.0, 0.0, 5.0),   // honnan nézzük a színteret  - eye
		glm::vec3(0.0, 0.0, 0.0),   // a színtér melyik pontját nézzük  - at
		glm::vec3(0.0, 1.0, 0.0));  // felfelé mutató irány a világban  - up

	m_cameraManipulator.SetCamera(&m_camera);

	return true;
}

void CMyApp::Clean()
{
	CleanShaders();
	CleanGeometry();
}

static float Function(float x, float z)
{
	return (x * (z - 2) + z * z) / 4;
}

static float ZCalculation(float speed, int range)
{
	return std::powf(std::fmod(speed, range) - (range / 2.f), 2.f) * 0.5f;
}

void CMyApp::Update(const SUpdateInfo& updateInfo)
{
	m_ElapsedTimeInSec = updateInfo.ElapsedTimeInSec;
	m_cameraManipulator.Update(updateInfo.DeltaTimeInSec);

	float speed = m_ElapsedTimeInSec * range / period;
	x = functionOn ? std::abs((std::fmod(speed, range * 2) - range) * 2) - range : 1.f;
	z = functionOn ? ZCalculation(speed, range) : 1.f;

	float scaling = scalingOn ? (std::abs(std::fmod(m_ElapsedTimeInSec, period) / period - 0.5f) * 6.f + 1.f) / 2.f : 1.f;

	m_objectWorldTransforms.clear();
	for (int i = 0; i < layouts[layoutIndex].size(); ++i)
	{
		glm::vec3 point = grid[layouts[layoutIndex][i]];

		m_objectWorldTransforms.push_back(
			glm::translate(glm::vec3(x, 1.f, z)) *

			glm::translate(glm::vec3(point.x, point.y * scaling, point.z)) *
			glm::scale(glm::vec3(1.f, scaling, 1.f)) *

			glm::rotate(glm::pi<float>() / 4.f, glm::vec3(0.f, 1.f, 0.f))
		);
	}
	
	for (int x = -4; x <= 4; x += 4)
	{
		for (int z = -4; z <= 4; z += 4)
		{
			for (int i = 0; i < layouts[layoutIndex].size(); ++i)
			{
				m_objectWorldTransforms.push_back(
					glm::translate(glm::vec3(x, Function(x, z), z)) *
					m_objectWorldTransforms[i]
				);
			}
		}
	}
}

void CMyApp::Render()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	glUseProgram(m_programID);

	glUniformMatrix4fv(ul("viewProj"), 1, GL_FALSE, glm::value_ptr(m_camera.GetViewProj()));

	for (int i = 0; i < m_objectWorldTransforms.size(); ++i)
	{
		glUniformMatrix4fv(ul("world"), 1, GL_FALSE, glm::value_ptr(m_objectWorldTransforms[i]));

		for (int i = vboIDs.size() - 1; i >= 0; --i)
		{
			glBindVertexArray(vaoIDs[i]);

			glDrawElements(GL_TRIANGLE_FAN, counts[i], GL_UNSIGNED_INT, nullptr);
		}
	}

	glUseProgram(0);

	glBindVertexArray(0);
}

void CMyApp::RenderGUI()
{
	if (ImGui::Button("Scaling"))
		scalingOn = !scalingOn;
	if (ImGui::Button("Function"))
		functionOn = !functionOn;
	if (!functionOn && !scalingOn)
		ImGui::SliderInt("Period", &period, 1, 20);
	if (!functionOn)
		ImGui::SliderInt("Range", &range, 1, 20);
	else
	{
		ImGui::SliderFloat("X", &x, -range, range);
		ImGui::SliderFloat("Z", &z, 0, ZCalculation(range, range));
	}
}

void CMyApp::KeyboardDown(const SDL_KeyboardEvent& key)
{
	if (key.repeat == 0)
	{
		if (key.keysym.sym == SDLK_F5 && key.keysym.mod & KMOD_CTRL)
		{
			CleanShaders();
			InitShaders();
		}
		if (key.keysym.sym == SDLK_F1)
		{
			GLint polygonModeFrontAndBack[2] = {};
			glGetIntegerv(GL_POLYGON_MODE, polygonModeFrontAndBack);

			GLenum polygonMode = (polygonModeFrontAndBack[0] != GL_FILL ? GL_FILL : GL_LINE);
			glPolygonMode(GL_FRONT_AND_BACK, polygonMode);
		}
		InitGeometry();
	}
	m_cameraManipulator.KeyboardDown(key);
}

void CMyApp::KeyboardUp(const SDL_KeyboardEvent& key)
{
	m_cameraManipulator.KeyboardUp(key);
}

void CMyApp::MouseMove(const SDL_MouseMotionEvent& mouse)
{
	m_cameraManipulator.MouseMove(mouse);
}

void CMyApp::MouseDown(const SDL_MouseButtonEvent& mouse)
{
}

void CMyApp::MouseUp(const SDL_MouseButtonEvent& mouse)
{
}

void CMyApp::MouseWheel(const SDL_MouseWheelEvent& wheel)
{
	m_cameraManipulator.MouseWheel(wheel);
}

void CMyApp::Resize(int _w, int _h)
{
	glViewport(0, 0, _w, _h);
	m_camera.SetAspect(static_cast<float>(_w) / _h);
}

void CMyApp::OtherEvent(const SDL_Event& ev)
{
}