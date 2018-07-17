using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;

namespace Services
{
    public class RandomService
    {
        public T FromCollection<T>(IEnumerable<T> collection)
        {
            var randomIndex = UnityEngine.Random.Range(0, collection.Count());
            return collection.ElementAt(randomIndex);
        }

        public IEnumerable<T> FromCollectionAmount<T>(IEnumerable<T> collection, int amount)
        {
            var result = new T[amount];
            var numToChoose = amount;

            for (var numLeft = collection.Count(); numLeft > 0; numLeft--)
            {
                var prob = (float)numToChoose / (float)numLeft;

                if (UnityEngine.Random.value <= prob)
                {
                    numToChoose--;
                    result[numToChoose] = collection.ElementAt(numLeft - 1);

                    if (numToChoose == 0)
                    {
                        break;
                    }
                }
            }

            return result;
        }
    }
}