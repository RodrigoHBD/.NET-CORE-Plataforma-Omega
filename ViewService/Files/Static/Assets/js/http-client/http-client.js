import HttpHelpers from "/js/http-client/http-helpers.js";

export default class HttpClient {
    Helpers = new HttpHelpers();

    async Get(uri, params = []) {
        try {
            if (params.length > 0) {
                uri = this.InjectParamsInUri(uri, params);
            }

            let response = await axios.get(uri);
            return response;
        }
        catch (error) {
            this.HandleRequestError(error);
        }
    }

    async Delete(uri, params = []) {
        try {
            if (params.length > 0) {
                uri = this.InjectParamsInUri(uri, params);
            }

            let response = await axios.delete(uri);
            return;
        }
        catch (error) {
            this.HandleRequestError(error);
        }
    }

    async Post(uri, body) {
        try {
            let response = await axios.post(uri, body,
                {
                    headers:
                    {
                        "Content-Type": "application/json"
                    }
                });
            return this.HandleResponse(response);
        }
        catch (error) {
            this.HandleRequestError(error);
        }
    }

    InjectParamsInUri(uri, params) {
        try {
            for (let i = 0; params.length - 1 >= i; i++) {
                let param = params[i];
                if (i === 0) {
                    uri = `${uri}?${param.name}=${param.value}`
                }
                else {
                    uri = `${uri}&${param.name}=${param.value}`
                }
            }
            return uri;
        }
        catch (error) {
            throw error;
        }
    }

    HandleRequestError(error) {
        console.log({ message: "Http Request Failed With Error", error });
    }

    HandleResponse(response) {
        try {
            if (response.status === 200) {
                return this.BuildResponseModel(response);
            }
            else {
                throw Error({ message: "Http Request Failed", axiosResponse: response });
            }
        }
        catch (error) {

        }
    }

    BuildResponseModel(axiosResponse) {
        try {
            let response = new ResponseModel();
            response.status = axiosResponse.status;
            response.body = axiosResponse.data;
            response.message = axiosResponse.statusText;
            response.header = axiosResponse.headers;
            return response;
        }
        catch (error) {
            throw error;
        }
    }
}


//interfaces

class ResponseModel {
    status;
    message;
    header;
    body;
}

class QueryStringParamModel {
    name;
    value;
}