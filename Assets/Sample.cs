using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Sample
{
    public class MyAnimator
    {
        /*private static Fabric GetFactory(string name)
        {
            
        }*/
        
        public async Task PlayAnimation(string objectName)
        {
            GameObject obj = null;
            
            // Используй Factory Method, чтобы дать возможность создавать разные объекты для анимации
            // Должна быть возможность использовать - все стандартные примитивы и объекты из префабов (с помощью паттерна Prototype)
            // Дай возможность использовать Builder для того, чтобы конфигурировать фабрику (задавать Scale и Rotation объекта)
            switch (objectName)
            {
                case "sphere":
                    new SphereCreator();
                    break;
                case "cube":
                    new CubeCreator();
                    return;
                default: throw new NotImplementedException();
            }

            var startPos = new Vector3();
            var endPos = new Vector3(10, 10, 10);
            var delay = 100;

            obj.transform.position = startPos;

            // Добавь возможность выбора анимации с помощью паттерна Strategy. Анимация не должна зависеть от типа
            // объекта, который ему передали
            while (true)
            {
                // С помощью паттерна Composite добавь возможность проигрывать несколько последовательных анимаций как одну
                // Создай два декоратора для анимаций - один добавляет событие окончания анимации, второй ускоряет анимацию
                obj.transform.position = Vector3.Lerp(obj.transform.position, endPos, delay);
                await Task.Delay(delay);
                if (Vector3.Distance(endPos, obj.transform.position) < 0.5f)
                    return;
            }
            // После всех изменений - выдели интерфейс полученного объекта и с помощью паттерна Decorator адаптируй его к 
            // IOtherAnimator<in TAnimation>
        }
    }

    public interface IOtherAnimator<in TAnimation>
    {
        void Animate(TAnimation animation, Action animationFinished);
    }

    public interface ICreateObjects
    {
        string Name { get;  }
        GameObject CreateGameObject();
    }

    public class Cube : ICreateObjects
    {
        private string name = "Cube";
        public string Name => name;

        public GameObject CreateGameObject()
        {
            return GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
    }

    public class Sphere : ICreateObjects
    {
        private string name = "Sphere";
        public string Name => name;
        public GameObject CreateGameObject()
        {
            return GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }
    }

    public abstract class Fabric
    {
        public abstract ICreateObjects FactoryMethod();
    }

    public class CubeCreator : Fabric
    {
        public override ICreateObjects FactoryMethod()
        {
            return new Cube();
        }
    }
    
    public class SphereCreator : Fabric
    {
        public override ICreateObjects FactoryMethod()
        {
            return new Sphere();
        }
    }
}