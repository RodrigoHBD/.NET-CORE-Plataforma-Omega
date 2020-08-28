class FormUtil {
    GetFormData(id) {
        try {
            return this.GetFormDataAndParseIt(id);
        }
        catch (error) {
            throw error;
        }
    }

    GetFormDataAndParseIt(id) {
        try {
            let data = this.GetSerializedData(id);
            return this.ParseSerializedDataToObject(data);
        }
        catch (error) {

        }
    }

    GetSerializedData(id) {
        try {
            return $(`#${id}`).serializeArray();
        }
        catch (error) {
            throw error;
        }
    }

    ParseSerializedDataToObject(array) {
        try {
            let object = new Object();
            for (let prop of array) {
                object[prop.name] = prop.value;
            }
            return object;
        }
        catch (error) {
            throw error;
        }
    }
}

class JsonUtil {

}

class StringUtil {

}

class EventsUtil {
    Click = (id) => {

    }
}

class Toolbox {
    Form = new FormUtil();
    Events = new EventsUtil();
}

var toolbox = new Toolbox();