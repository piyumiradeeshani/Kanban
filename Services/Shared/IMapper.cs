using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Shared
{
     public interface IMapper<TSource, TDestination>
     {
         TDestination Map(TSource sourceObject);
     }
 }
