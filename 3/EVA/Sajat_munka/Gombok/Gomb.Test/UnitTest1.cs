using HOK.Gomb.Model;
using HOK.Gomb.Persistence;
using Moq;

namespace ELTE.Sudoku.Test
{
	[TestClass]
	public class SudokuGameModelTest
	{
		private GombGameModel _model = null!;
		private GombTable _mockedTable = null!;
		private Mock<IGombDataAccess> _mock = null!;

		[TestInitialize]
		public void Initialize()
		{
			_mockedTable = new GombTable(true, false);

			_mock = new Mock<IGombDataAccess>();
			_mock.Setup(mock => mock.LoadAsync(It.IsAny<string>()))
				.Returns(() => Task.FromResult(_mockedTable));

			_model = new GombGameModel(_mock.Object);

			_model.Handler += new EventHandler<GombEventArgs>(Model_Handler);
		}


		[TestMethod]
		public void GombGameModelNewGameTest()
		{
			_model.NewGame();

			Assert.IsNotNull(_model.Table);

			Assert.AreEqual(false, _model.Table.Light1);
			Assert.AreEqual(false, _model.Table.Light2);
		}

		[TestMethod]
		public void GombGameModelButtonPushTest()
		{
			_model.NewGame();

			Assert.IsNotNull(_model.Table);

			Assert.AreEqual(false, _model.Table.Light1);
			Assert.AreEqual(false, _model.Table.Light2);

			_model.Table.SwitchLight1();

			Assert.AreEqual(true, _model.Table.Light1);
			Assert.AreEqual(false, _model.Table.Light2);

			_model.Table.SwitchLight1();

			Assert.AreEqual(false, _model.Table.Light1);
			Assert.AreEqual(false, _model.Table.Light2);


			_model.Table.SwitchLight2();

			Assert.AreEqual(false, _model.Table.Light1);
			Assert.AreEqual(true, _model.Table.Light2);

			_model.Table.SwitchLight2();

			Assert.AreEqual(false, _model.Table.Light1);
			Assert.AreEqual(false, _model.Table.Light2);
		}

		[TestMethod]
		public async Task GombGameModelLoadTest()
		{
			_model.NewGame();

			Assert.AreEqual(false, _model.Table.Light1);
			Assert.AreEqual(false, _model.Table.Light2);

			await _model.LoadGameAsync(string.Empty);

			Assert.AreEqual(true, _model.Table.Light1);
			Assert.AreEqual(false, _model.Table.Light2);

			_mock.Verify(dataAccess => dataAccess.LoadAsync(string.Empty), Times.Once());
		}

		private void Model_Handler(object? sender, GombEventArgs e)
		{
			Assert.AreEqual(_model.Table.Light1, e.One);
			Assert.AreEqual(_model.Table.Light2, e.Two);
		}
	}
}
