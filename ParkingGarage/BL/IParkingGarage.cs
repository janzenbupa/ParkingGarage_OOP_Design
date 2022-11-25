namespace ParkingGarage.BL
{
    public interface IParkingGarage
    {
        public T ProcessRequest<T, G>(G request);
    }
}
