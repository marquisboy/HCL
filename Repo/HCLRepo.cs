using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HCLProj.Repo;

namespace HCLProj.Repo
{
    public class HCLRepo : IHCLRepo
    {
        private HCL2Entities context = new HCL2Entities();

        public IEnumerable<Car> Cars
        {
            get { return context.Cars; }
        }

        public void SaveCar( Car carParam )
        {
            if ( carParam.id == 0 )
            {
                context.Cars.Add(carParam);
            }
            else
            {
                Car car = context.Cars.Find(carParam.id);
                if ( car != null )
                {
                    car.body_style = carParam.body_style;
                    car.co2 = carParam.co2;
                    car.doors = carParam.doors;
                    car.drive_type = carParam.drive_type;
                    car.engine_bore_mm = carParam.engine_bore_mm;
                    car.engine_cc = carParam.engine_cc;
                    car.engine_compression = carParam.engine_compression;
                    car.engine_fuel = carParam.engine_fuel;
                    car.engine_num_cyl = carParam.engine_num_cyl;
                    car.engine_position = carParam.engine_position;
                    car.engine_power_ps = carParam.engine_power_ps;
                    car.engine_power_rpm = carParam.engine_power_rpm;
                    car.engine_stroke_mm = carParam.engine_stroke_mm;
                    car.engine_torque_nm = carParam.engine_torque_nm;
                    car.engine_torque_rpm = carParam.engine_torque_rpm;
                    car.engine_type = carParam.engine_type;
                    car.engine_valves_per_cyl = carParam.engine_valves_per_cyl;
                    car.fuel_capacity_l = carParam.fuel_capacity_l;
                    car.height_mm = carParam.height_mm;
                    car.length_mm = carParam.length_mm;
                    car.lkm_city = carParam.lkm_city;
                    car.lkm_hwy = carParam.lkm_hwy;
                    car.lkm_mixed = carParam.lkm_mixed;
                    car.make = carParam.make;
                    car.make_display = carParam.make_display;
                    car.model_name = carParam.model_name;
                    car.model_trim = carParam.model_trim;
                    car.model_year = carParam.model_year;
                    car.seats = carParam.seats;
                    car.sold_in_us = carParam.sold_in_us;
                    car.top_speed_kph = carParam.top_speed_kph;
                    car.transmission_type = carParam.transmission_type;
                    car.weight_kg = carParam.weight_kg;
                    car.wheelbase = carParam.wheelbase;
                    car.width_mm = carParam.width_mm;
                    car.zero_to_100_kph = carParam.zero_to_100_kph;
                }
            }

            context.SaveChanges();
        }

        public Car GetCar(int id)
        {
            Car car = context.Cars.FirstOrDefault(c=>c.id == id);

            return car;
        }

        public Car DeleteCar(int id)
        {
            Car car = null;

            return car;
        }


    }
}