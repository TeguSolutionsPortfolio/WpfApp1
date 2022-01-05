namespace Solutions
{
    public static class Solutions
    {
        #region Task 2

        private static (bool hasCars, int remainingPeople) TryFillNextAvailableCar(IEnumerable<Car> cars, int people)
        {
            var nextAvailableCar = cars.FirstOrDefault(c => c.AvailableSeats > 0);
            // There is no car with empty seats
            if (nextAvailableCar is null)
                return (false, 0);

            var remainingPeople = nextAvailableCar.SeatPeople(people);
            return (true, remainingPeople);
        }

        public static int solution2(int[] p, int[] s)
        {
            var orderedPeople = p.ToList();
            orderedPeople.Sort();
            orderedPeople.Reverse();

            var orderedSeats = s.ToList();
            orderedSeats.Sort();
            orderedSeats.Reverse();

            var cars = orderedSeats.Select(orderedSeat => new Car(orderedSeat)).ToList();

            foreach (var op in orderedPeople)
            {
                var remainingPeople = op;

                // Just loop until there are people from the group and still have available cars
                // And find a nicer solution, like a while loop, etc.., it's ugly, but working.
                for (var i = 0; i < 1000; i++)
                {
                    var result = TryFillNextAvailableCar(cars, remainingPeople);
                    if (!result.hasCars)
                        return cars.Count(c => c.FilledSeats > 0);
                    else
                        remainingPeople = result.remainingPeople;

                    if (remainingPeople == 0)
                        break;
                }
            }

            return cars.Count(c => c.FilledSeats > 0);
        }

        internal class Car
        {
            public Car(int allSeats)
            {
                AllSeats = allSeats;
            }

            public int AllSeats { get; private set; }
            public int FilledSeats { get; private set; }

            public int AvailableSeats => AllSeats - FilledSeats;

            /// <summary>
            /// Returns the remaining people who doesn't fit in the car
            /// </summary>
            public int SeatPeople(int people)
            {
                // There is enough space to seat everyone
                if (AvailableSeats >= people)
                {
                    FilledSeats += people;
                    return 0;
                }
                // If not, just fill up the available space
                else
                {
                    FilledSeats += AvailableSeats;
                    return people - AvailableSeats;
                }
            }
        }

        #endregion
    }
}