using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class TextSpritesLoader
    {
        string workingDirectory = Environment.CurrentDirectory;

        string projectDirectory;

        string playerShip1Path = @"Assets\TextView\PlayerShip1.txt";
        string playerShip2Path = @"Assets\TextView\PlayerShip2.txt";
        string playerShip3Path = @"Assets\TextView\PlayerShip3.txt";

        string bulletPath = @"Assets\TextView\Bullet.txt";

        string enemyShip1Path = @"Assets\TextView\EnemyShip1.txt";
        string enemyShip2Path = @"Assets\TextView\EnemyShip2.txt";
        string enemyShip3Path = @"Assets\TextView\EnemyShip3.txt";


        public TextSpritesLoader() {
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;

            playerShip1Path = Path.Combine(projectDirectory, playerShip1Path);
            playerShip2Path = Path.Combine(projectDirectory, playerShip2Path);
            playerShip3Path = Path.Combine(projectDirectory, playerShip3Path);

            bulletPath = Path.Combine(projectDirectory, bulletPath);

            enemyShip1Path = Path.Combine(projectDirectory, enemyShip1Path);
            enemyShip2Path = Path.Combine(projectDirectory, enemyShip2Path);
            enemyShip3Path = Path.Combine(projectDirectory, enemyShip3Path);

            TextViewSprites.EnemyShip1 = File.ReadAllText(enemyShip1Path);
            TextViewSprites.EnemyShip2 = File.ReadAllText(enemyShip2Path);
            TextViewSprites.EnemyShip3 = File.ReadAllText(enemyShip3Path);

            TextViewSprites.Bullet = File.ReadAllText(bulletPath);

            TextViewSprites.PlayerShip1 = File.ReadAllText(playerShip1Path);
            TextViewSprites.PlayerShip2 = File.ReadAllText(playerShip2Path);
            TextViewSprites.PlayerShip3 = File.ReadAllText(playerShip3Path);
        }
    }
}
