using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAlgorithm
{
   class Board
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] Tile { get; private set; }
        public int Size { get; private set; }

        Player _player;

        public enum TileType
        {
            Empty,
            Wall,
            Player,
        }

        public void Initialize(int size, Player player)
        {
            if (size % 2 == 0)
                return;

            Tile = new TileType[size, size];
            Size = size;
            _player = player;

            GenerateSideWinderTree();
        }

        void GenerateSideWinderTree()
        {
            // 길 막아 버리기
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;
                }
            }

            // 랜덤으로 우측 혹은 아래로 길 뚫기
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                int count = 1;
                for (int x = 0; x < Size; x++)
                {
                    // 벽으로 막아버린 부분은 패스
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == Size - 2 && x == Size - 2)
                        continue;

                    // 최외곽에서 한쪽 방향으로만 가게 막음
                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }


                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomIndex = rand.Next(0, count);
                        Tile[y + 1, x - randomIndex * 2] = TileType.Empty;
                        count = 1;
                    }
                }
            }
        }

        void GenerateByBinaryTree()
        {
            // 길 막아 버리기
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;
                }
            }

            // 랜덤으로 우측 혹은 아래로 길 뚫기
            Random rand = new Random();
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    // 벽으로 막아버린 부분은 패스
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (y == Size - 2 && x == Size - 2)
                        continue;

                    // 최외곽에서 한쪽 방향으로만 가게 막음
                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }
                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    // 1/2 확률로 양방향 중 한쪽만 길 뚫기
                    if (rand.Next(0, 2) == 0)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        Tile[y + 1, x] = TileType.Empty;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor precColor = Console.ForegroundColor;
            for(int y=0;y<Size;y++) 
            {
                for(int x= 0;x<Size;x++)
                {
                    // 플레이어 좌표 갖고 와서, 그 좌표와 y,x가 일치하면 플레이어 색
                    if(y==_player.PosY && x==_player.PosX)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ForegroundColor = GetTileColor(Tile[y, x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = precColor;
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch(type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType .Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }
    }
}
