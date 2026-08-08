#pragma once

// GLM
#include <glm/glm.hpp>
#include <glm/gtc/type_ptr.hpp>
#include <glm/gtx/transform.hpp>

// GLEW
#include <GL/glew.h>

// SDL
#include <SDL2/SDL.h>
#include <SDL2/SDL_opengl.h>

// Utils
#include "GLUtils.hpp"
#include "Camera.h"
#include "CameraManipulator.h"

struct SUpdateInfo
{
	float ElapsedTimeInSec = 0.0f; // Program indulása óta eltelt idő 
	float DeltaTimeInSec = 0.0f; // Előző Update óta eltelt idő 
};

class CMyApp
{
public:
	CMyApp();
	~CMyApp();

	bool Init();
	void Clean();

	void Update(const SUpdateInfo&);
	void Render();
	void RenderGUI();

	void KeyboardDown(const SDL_KeyboardEvent&);
	void KeyboardUp(const SDL_KeyboardEvent&);
	void MouseMove(const SDL_MouseMotionEvent&);
	void MouseDown(const SDL_MouseButtonEvent&);
	void MouseUp(const SDL_MouseButtonEvent&);
	void MouseWheel(const SDL_MouseWheelEvent&);
	void Resize(int, int);

	void OtherEvent(const SDL_Event&);
protected:
	void SetupDebugCallback();

	// Adat változók
	float m_ElapsedTimeInSec = 0.0f;
	
	std::vector<glm::mat4> m_objectWorldTransforms;

	int sides = 4;

	std::vector<glm::vec3> colors = {
		glm::vec3(0, 0, 0),
		glm::vec3(1, 0, 0),
		glm::vec3(0, 1, 0),
		glm::vec3(0, 0, 1),
		glm::vec3(1, 1, 0),
		glm::vec3(1, 0, 1),
		glm::vec3(0, 1, 1),
		glm::vec3(1, 1, 1)
	};

	bool scalingOn = true;
	bool functionOn = true;
	int period = 10;
	int range = 10;
	float x = 0;
	float z = 0;

	// Kamera 
	Camera m_camera;
	CameraManipulator m_cameraManipulator;

	// OpenGL-es dolgok

	// Shaderekhez szükséges változók 
	GLuint m_programID = 0;

	// Shaderek inicializálása, és törlése 
	void InitShaders();
	void CleanShaders() const;

	// Geometriával kapcsolatos változók 
	std::vector<GLuint>  vaoIDs;
	std::vector<GLuint>  vboIDs;
	std::vector<GLuint>  iboIDs;
	std::vector<GLsizei> counts;

	int layoutIndex = 0;

	std::vector<glm::vec3> grid =
	{
			glm::vec3(0, 2, 0),
			glm::vec3(-1, 1, 0),
			glm::vec3(0, 1, 0),
			glm::vec3(1, 1, 0),
			glm::vec3(-1, 0, 0),
			glm::vec3(0, 0, 0),
			glm::vec3(1, 0, 0),
			glm::vec3(-1, -1, 0),
			glm::vec3(0, -1, 0),
			glm::vec3(1, -1, 0),
			glm::vec3(0, -2, 0)
	};

	std::vector<std::vector<int>> layouts =
	{
		{ 1, 4, 7, 8, 9 },
		{ 1, 2, 3, 5, 8 },
		{ 3, 5, 6, 7, 8 },
		{ 2, 4, 5, 6, 8 },
		{ 4, 6, 7, 8, 9 },
		{ 1, 2, 5, 8, 9 },
		{ 2, 3, 4, 5, 8 },
		{ 2, 3, 5, 6, 8 },
		{ 0, 2, 5, 8, 10 },
		{ 2, 3, 5, 6, 8, 10 },
		{ 2, 4, 5, 8, 10 },
		{ 0, 2, 5, 9, 10 }
	};

	void InitTriangleFan(std::vector<glm::vec3>& points, std::vector<int> indexesInvolved);
	void InitGeometry();
	void CleanGeometry();
};

