using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Space_Shooter
{
    public class GameObjectsController
    {
        List<GameObject> gameObjects = new List<GameObject>();

        CollidersMap colliderMap = new CollidersMap();
        EnemySpawnController enemySpawnController = new EnemySpawnController();
        public TextViewGameController textViewController = new TextViewGameController();
        int enteredColliderID;

        public void addGameObject(GameObject go)
        {
            go.id = gameObjects.Count;
            go.collider.id = go.id;
            gameObjects.Add(go);
            colliderMap.setCollider(go.collider);
        }

        public PlayerShip addPlayerShip(int id)
        {
            PlayerShip playerShip = ShipsData.getPlayerShip(id);
            addGameObject(playerShip);
            return playerShip;
        }

        public void addEnemyShip(int id) {
            EnemyShip enemyShip = ShipsData.getEnemyShip(id);
            addGameObject(enemyShip);
        }

        public void something()
        {
            Console.SetCursorPosition(Globals.COLLIDER_WIDTH + Globals.LEFT_OFFSET, Globals.COLLIDER_HEIGHT + Globals.TOP_OFFSET);
                colliderMap.writeCollider();

        }

        public void invokeAllEnviromentMethods()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject item = gameObjects[i];
                if(item.type == GameObjectType.Bullet
                    || item.type == GameObjectType.EnemyShip)
                {
                    if (item.type == GameObjectType.EnemyShip)
                    {
                        Bullet spawnedBullet;
                        EnemyShip enemyShip = (EnemyShip)item;
                        enemyShip.move();

                        if((spawnedBullet = enemyShip.shoot() )!= null)
                        {
                            addGameObject((GameObject)spawnedBullet);
                        }
                        
                    }
                    moveGameObject(item, item.xSpeed, item.ySpeed);
                }
            }
            int spawnedEnemyId;
            if ((spawnedEnemyId = enemySpawnController.SpawnEnemy()) != -1)
            {
                addEnemyShip(spawnedEnemyId);
                enemySpawnController.randomiseSpawnTransform(gameObjects[gameObjects.Count-1].collider.transform);
            }
        }


        public void removeGameObject(GameObject go)
        {
            gameObjects.RemoveAt(go.id);
            colliderMap.clearCollider(go.collider);
            textViewController.clearObject(go);
            for (int i = go.id; i < gameObjects.Count; i++)
            {
                gameObjects[i].id--;
                gameObjects[i].collider.id--;
            }
        }

        public void moveGameObject(GameObject go, int moveByX, int moveByY)
        {

            if(go.collider.transform.x + moveByX + go.collider.colliderWidth >= Globals.COLLIDER_WIDTH
                || go.collider.transform.x + moveByX <= 0 
                || go.collider.transform.y + moveByY + go.collider.colliderHeight >= Globals.COLLIDER_HEIGHT
                || go.collider.transform.y + moveByY <= 0)
            {
                if (go.type == GameObjectType.Bullet
                 || go.type == GameObjectType.EnemyShip)
                {
                    removeGameObject(go);
                }

                return;
            }

            colliderMap.clearCollider(go.collider);

            /* go.collider.transform.x +=moveByX;
             go.collider.transform.y +=moveByY;*/
                
            textViewController.moveObject(go, moveByX, moveByY);

            if ((enteredColliderID = colliderMap.setCollider(go.collider)) != -1)
            {
                if (go.type == GameObjectType.Bullet)
                {
                    Bullet bullet = (Bullet)go;
                    if (gameObjects[enteredColliderID].type == GameObjectType.PlayerShip) 
                    {
                        PlayerShip ship = (PlayerShip)gameObjects[enteredColliderID];

                        if (ship.getDamage(bullet.damage))
                        {
                            
                            enemySpawnController.currentSpawningTime = Globals.STARTING_ENEMY_SPAWN_TIME;
                            Globals.GAMESTATE = GameState.GameOverScreen;
                        }

                        textViewController.updateHP(ship.hp);

                        removeGameObject(bullet);


                        if(Globals.GAMESTATE == GameState.GameOverScreen)
                        {
                            int gameObjectsCount = gameObjects.Count;
                            for (int i = 0; i < gameObjectsCount; i++)
                            {
                                removeGameObject(gameObjects[0]);
                            }
                        }

                    }
                    else if (gameObjects[enteredColliderID].type == GameObjectType.EnemyShip)
                    {
                        EnemyShip enemyShip = (EnemyShip)gameObjects[enteredColliderID];

                        if (enemyShip.getDamage(bullet.damage))
                        {
                            removeGameObject(enemyShip);

                            removeGameObject(bullet);

                            Globals.CURRENT_SCORE++;
                            textViewController.updateScore();
                        }
                        else
                        {
                            removeGameObject(bullet);

                        }
                    }
                }
            }
        }
    }
}
