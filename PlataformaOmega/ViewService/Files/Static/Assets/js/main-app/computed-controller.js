class ComputedController {
    Initialize() {
        try {
            
        }
        catch (error) {
            throw error;
        }
    }
    ExportComputed() {
        try {
            var computed = new Computed();
            
            return computed;
        }
        catch (error) {
            throw error;
        }
    }
}

class Computed {
    CCorreios = ()=>{ return new CorreiosComputed(); }
}