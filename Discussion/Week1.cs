namespace Discussion
{
    internal class Week1
    {
        static void Main(string[] args)
        {
           // var car = new RemoteControlCar(5, 2);
           // var raceTrack = new RaceTrack(1800);
           // var nirto = RemoteControlCar.Nitro();
            //Console.WriteLine("Car can finish ? " + raceTrack.TryFinishTrack(nirto));
            //for (int i = 0; i < 50; i++) {
            //car.Drive();
            //}
            //Console.WriteLine(car.DistanceDriven());
            // Console.WriteLine(car.BatteryDrained());
            var text = "7/25/2019 13:45:00".Split(' ');
            Console.WriteLine(Appointment.Schedule("7/25/2019 13:45:00"));
            Console.WriteLine(Appointment.HasPassed(Appointment.Schedule("7/25/2019 13:45:00")));

        }
    }

    class Appointment {
        public static DateTime Schedule(String textDate)
        {
            //Appointment.Schedule("7/25/2019 13:45:00")
            // => new DateTime(2019, 7, 25, 13, 45, 0)
            // 7/25/2019 => 7 , 25 , 2019
            var dateText = textDate.Split(' ');
            var date = dateText[0];
            var time = dateText[1];
            return new DateTime(Int32.Parse(date.Split("/")[2]), Int32.Parse(date.Split("/")[0]), Int32.Parse(date.Split("/")[1]),
                                Int32.Parse(time.Split(":")[0]), Int32.Parse(time.Split(":")[1]), Int32.Parse(time.Split(":")[2]));
        }

        public static bool HasPassed(DateTime dt)
        {
            return DateTime.Now.CompareTo(dt) >= 0;
        }
    }

    class RemoteControlCar {
        private int speed;
        private int battery = 100;
        private int batteryDrainPercentage;
        private int distanceDriven;

        public RemoteControlCar(int speed, int batteryDrainPercentage) {
            this.speed = speed;
            this.batteryDrainPercentage = batteryDrainPercentage;
        }

        public void Drive() {
            this.distanceDriven += this.speed;
            this.battery -= batteryDrainPercentage;
        }

        public int DistanceDriven() {
            return this.distanceDriven;
        }

        public bool BatteryDrained() {
            //if (this.battery <= 0) {
            //    return true;
            //} else {
            //    return false;
            //}
            //return this.battery <= 0 ? true : false; 
            return this.battery <= 0;
        }

        public static RemoteControlCar Nitro() {
            return new RemoteControlCar(50, 4);
        }
    }

    class RaceTrack {
        private int distance;

        public RaceTrack(int distance) {
            this.distance = distance;
        }

        public bool TryFinishTrack(RemoteControlCar car) {
            // if the distance can be finished before the battery drained
            while (!car.BatteryDrained()) {
                car.Drive();
                if (car.DistanceDriven() >= this.distance) { 
                    return true;
                }
            }
            return false;
        }
    }
}
