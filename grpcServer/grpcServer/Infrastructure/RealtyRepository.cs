using DowntownRealty;
using grpcServer.Core;
using grpcServer.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace grpcServer.Infrastructure
{
    public class RealtyRepository : IRealtyRepository
    {
        Dictionary<RealtyTypeEntity, RealtyAdEntity[]> realtyDictionary;

        public RealtyRepository()
        {
            var fileDictionary = File.ReadAllText(@".\AppData\Realty.json");
            realtyDictionary = JsonConvert.DeserializeObject<Dictionary<RealtyTypeEntity, RealtyAdEntity[]>>(fileDictionary);
        }

        public RealtyAdEntity[] ListByName(RealtyTypeEntity names)
        {
            if(!realtyDictionary.Keys.Contains(names))
            {
                throw new KeyNotFoundException("Author didnt foud");
            }

            return realtyDictionary[names].ToArray();
        }
    }
}
