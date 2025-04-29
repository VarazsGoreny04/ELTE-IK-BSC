using ELTE.Snake.Model;
using ELTE.Snake.Persistence;
using Moq;
using System.Drawing;

namespace ELTE.Snake.Test
{
	[TestClass]
	public class SnakeGameModelTest
	{
		private const uint TABLESIZE = 15u;

		private SnakeGameModel _model = null!;
		private SnakeTable _mockedTable = null!;
		private Mock<ISnakeDataAccess> _mock = null!;

		private bool _runGame;
		private Point _oldHead;
		private Size _dir;

		[TestInitialize]
		public void InitializeTests()
		{
			_mockedTable = new SnakeTable(TABLESIZE);
			_mockedTable.InitializeSnake(TABLESIZE);
			_mockedTable.AddWall(new Point(1, 2));
			_mockedTable.AddWall(new Point(13, 1));
			_mockedTable.AddWall(new Point(8, 2));

			_mock = new Mock<ISnakeDataAccess>();

			_mock.Setup(mock => mock.LoadAsync(It.IsAny<uint>(), It.IsAny<string>()))
				 .Returns(Task.FromResult(_mockedTable));

			_model = new SnakeGameModel(_mock.Object);
			_model.GameCreated += new EventHandler<SnakeEventArgs>(GameCreatedTest);
			_model.Moving += new EventHandler<SnakeFieldEventArgs>(MovingTest);
			_model.EndGame += new EventHandler<SnakeEventArgs>(EndGameTest);
		}

		[TestMethod]
		[DataRow(TABLESIZE)]
		public async Task SnakeGameModelNewGameTest(uint tableSize)
		{
			await _model.NewGame(tableSize, string.Empty);

			Assert.AreEqual(tableSize, _model.Table.Size);
			Assert.AreEqual(0u, _model.Table.Score);
			Assert.AreEqual(5, _model.Table.Snake.Count);

			for (int i = 0; i < _model.Table.Snake.Count - 1; ++i)
				for (int j = i + 1; j < _model.Table.Snake.Count; ++j)
					Assert.IsTrue(_model.Table.Snake[i] != _model.Table.Snake[j]);

			for (int i = 0; i < _model.Table.Walls.Count - 1; ++i)
				for (int j = i + 1; j < _model.Table.Walls.Count; ++j)
					Assert.IsTrue(_model.Table.Walls[i] != _model.Table.Walls[j]);
		}

		[TestMethod]
		[DataRow(TABLESIZE)]
		public async Task SnakeGameModelStepTest(uint tableSize)
		{
			_runGame = true;

			await _model.NewGame(tableSize, string.Empty);

			Random random = new();
			int rnd, oldRnd = 3;
			List<Size> directions = new()
			{
				new Size(0, 1),
				new Size(-1, 0),
				new Size(0, -1),
				new Size(1, 0)
			};

			while (_runGame)
			{
				_oldHead = _model.Table.Snake[^1];
				rnd = random.Next(4);

				if (Math.Abs(rnd - oldRnd) != 2)
				{
					_dir = directions[rnd];
					oldRnd = rnd;
				}
				else
					_dir = directions[oldRnd];

				_model.SetDirection((Dir)rnd);

				_model.Step();
			}
		}

		private void GameCreatedTest(object? sender, SnakeEventArgs e)
		{
			Assert.AreEqual(false, e.IsWon);
			Assert.AreEqual(_model.Table.Score, e.Score);
			Assert.AreEqual(true, e.EmptyField);
		}

		private void MovingTest(object? sender, SnakeFieldEventArgs e)
		{
			Assert.AreEqual(_oldHead + _dir, _model.Table.Snake[^1]);
			Assert.IsTrue(e.HeadField != _model.Table.Apple || e.TailField is null);
		}

		private void EndGameTest(object? sender, SnakeEventArgs e)
		{
			_runGame = false;

			if (e.IsWon)
			{
				Assert.AreEqual(_model.Table.Size * _model.Table.Size, (uint)(_model.Table.Snake.Count + _model.Table.Walls.Count));
			}
		}
	}
}