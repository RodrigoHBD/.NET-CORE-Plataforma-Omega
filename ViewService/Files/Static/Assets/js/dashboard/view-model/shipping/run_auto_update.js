import RunAutoUpdateMethod from "/js/main-app/controllers/shipping/methods/run_auto_update.js";

export default class RunAutoUpdate {
    async Run(){
        var method = new RunAutoUpdateMethod();
        await method.Run();
    }

    async RunById(id){
        var method = new RunAutoUpdateMethod();
        await method.RunById(id);
    }

}