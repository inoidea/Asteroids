using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    internal sealed class GameService
    {
        public void Start()
        {
            StartGame();
        }
        private void StartGame()
        {
            var game = new GameStarter();
            game.Start();
        }
    }
}
