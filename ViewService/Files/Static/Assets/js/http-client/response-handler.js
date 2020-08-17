class ResponseHandler {
    ExceptionBuilder = [
        new InternalServerErrorExceptionBuilder(),
        new NotFoundExceptionBuilder(),
        new BadRequestExceptionBuilder()
    ];
    HandleResponse(response, config = new HandleConfig()) {
        var status = response.status;

        if (config.UseExpectedStatus) {
            var statusMatches = status == config.ExpectedStatus;
            var exceptionBuilder = this._FindCustomExceptionHandlerForStatus(status);
            var statusHasExceptionBuilder = exceptionBuilder != null;

            if (!statusMatches) {
                if (statusHasExceptionBuilder) {
                    throw exceptionBuilder.Build(response);
                }
                else {
                    throw this._CreateGenericStatusMismatchException(response);
                }
            }
        }

        return response.data;
    }

    _CreateGenericStatusMismatchException(response) {
        return new Error(`A requisicao HTTP falhou com status: ${response.status}. 
        Dados do erro: ${response.body}`);
    }

    _FindCustomExceptionHandlerForStatus(status) {
        return this.ExceptionBuilder.find(builder => builder.Status == status);
    }
}

class HandleConfig {
    ReturnRawDeserializedResponse;
    ExpectedStatus;
    UseExpectedStatus;
    UseDefaultExceptionBuilders;

    constructor() {
        var defaults = new HandleConfigDefaults();

        this.ExpectedStatus = defaults.ExpectedStatus;
        this.UseExpectedStatus = defaults.UseExpectedStatus;
        this.UseDefaultExceptionBuilders = defaults.UseDefaultExceptionBuilders;
    }
}

class HandleConfigDefaults {
    //TODO  
    ReturnRawDeserializedResponse = true;
    ExpectedStatus = 200;
    UseExpectedStatus = true;
    ExceptionCallback = () => { };
    UseDefaultExceptionBuilders = true;
}

class ResponseHandlerExceptionBuilder {
    Status = 0;
    Build = () => { };
}

class InternalServerErrorExceptionBuilder extends ResponseHandlerExceptionBuilder {
    Status = 500;
    Build = () => {
        return new Error("Erro Interno nos servidores, tente mais tarde");
    };
}

class NotFoundExceptionBuilder extends ResponseHandlerExceptionBuilder {
    Status = 404;
    Build = () => {
        return new Error("Recurso nao encontrado");
    };
}

class BadRequestExceptionBuilder extends ResponseHandlerExceptionBuilder {
    Status = 400;
    Build = () => {
        return new Error("Requisicao mal feita");
    };
}

export default { ResponseHandler, HandleConfig, ResponseHandlerExceptionBuilder };