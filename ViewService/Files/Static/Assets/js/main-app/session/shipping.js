export default class ShippingSession {
    WatcherState = new PackageWatcherRoutineState();
} 

class PackageWatcherRoutineState {
    IsInitialized = false;
    IsExecuting = false;
    IsPaused = false;
    LastExecutedAt = "";
    NextExecutionAt = "";
}