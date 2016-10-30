using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCLProj.Repo
{
    public interface IHCLRepo
    {
        IEnumerable<Car> Cars { get; }

        void SaveCar(Car car);
        Car GetCar(int Id);
        Car DeleteCar(int Id);

    }
}
