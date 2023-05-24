
namespace TickTackToe.Tables
{
	public class Table3X3 : Table
	{
		public override Position[,] Positions => _coordinates;
		private readonly Position[,] _coordinates = new Position[3,3];
		
		public Table3X3()
		{
			CreateCoordinates3X3();
		}
		private void CreateCoordinates3X3()
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					_coordinates[i, j] = new Position(i, j);
				}
			}
		}

	}
}