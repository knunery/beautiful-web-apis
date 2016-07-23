using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Feature.Llamas
{
    public interface ILlamaRepository
    {
        void Add(Llama item);
        IEnumerable<Llama> GetAll();
        Llama Find(string key);
        Llama Remove(string key);
        void Update(Llama item);
    }

    public class LlamaRepository : ILlamaRepository
    {
        private static ConcurrentDictionary<string, Llama> _Llamas = 
              new ConcurrentDictionary<string, Llama>();

        public LlamaRepository()
        {
            Add(new Llama { Name = "Mark" });
        }

        public IEnumerable<Llama> GetAll()
        {
            return _Llamas.Values;
        }

        public void Add(Llama item)
        {
            item.Key = Guid.NewGuid().ToString();
            _Llamas[item.Key] = item;
        }

        public Llama Find(string key)
        {
            Llama item;
            _Llamas.TryGetValue(key, out item);
            return item;
        }

        public Llama Remove(string key)
        {
            Llama item;
            _Llamas.TryGetValue(key, out item);
            _Llamas.TryRemove(key, out item);
            return item;
        }

        public void Update(Llama item)
        {
            _Llamas[item.Key] = item;
        }
    }
}