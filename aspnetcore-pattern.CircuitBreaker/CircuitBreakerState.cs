namespace aspnetcore_pattern.CircuitBreaker
{
    public enum CircuitBreakerState
    {
        Closed,
        Open,
        HalfOpen
    }
}
