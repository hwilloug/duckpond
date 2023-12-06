using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class OpenPacks : MonoBehaviour
{
    Random rnd = new Random();
    public int ducksPerPack = 3;

    public GameObject mallard;
    public GameObject wood;
    public GameObject ruddy;

    void OnMouseDown()
    {
        CalculateDucks();
        Destroy(gameObject);
    }

    void CalculateDucks()
    {
        WeightedList<int> duckTable = new WeightedList<int>();
        duckTable.AddEntry(0, 6);
        duckTable.AddEntry(1, 3);
        duckTable.AddEntry(2, 1);
        for (int pack = 0; pack < ducksPerPack; pack++)
        {
            int winningDuck = duckTable.GetRandom();
            switch(winningDuck)
            {
                case 0:
                    Instantiate(mallard);
                    break;
                case 1:
                    Instantiate(ruddy);
                    break;
                case 2:
                    Instantiate(wood);
                    break;
            }
        }
    }

    class WeightedList<T> {
        private struct Entry {
            public T Item;
            public int Threshold;
        }
        private List<Entry> _entries = new List<Entry>();
        private int _totalWeight;
        public void AddEntry(T item, int weight) {
            _totalWeight += weight;
            _entries.Add(new Entry { Item = item, Threshold = _totalWeight });
        }
        private Random _rand = new Random();
        public T GetRandom() {
            int r = _rand.Next(1, _totalWeight + 1);
            foreach (Entry entry in _entries) {
                if (r <= entry.Threshold) return entry.Item;
            }
            return default;
        }
    }
}
