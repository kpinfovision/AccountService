using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public class MappingProfile
    {
        private IMapper Mapper { get; }

        public MappingProfile()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        public T Map<T>(object source) where T : class
        {
            return Mapper.Map<T>(source);
        }
    }
}
