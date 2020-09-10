class FormUtil {
    GetFormData(id) {
        try {
            return this._GetFormDataAndParseIt(id);
        }
        catch (error) {
            throw error;
        }
    }

    _GetFormDataAndParseIt(id) {
        try {
            let data = this._GetSerializedData(id);
            return this._ParseSerializedDataToObject(data);
        }
        catch (error) {

        }
    }

    _GetSerializedData(id) {
        try {
            return $(`#${id}`).serializeArray();
        }
        catch (error) {
            throw error;
        }
    }

    _ParseSerializedDataToObject(array) {
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

    Clear(id) {
        document.getElementById(id).reset();
    }
}

class JsonUtil {

}

class StringUtil {

}

class EventsUtil {
    Click = (id) => {
        var element = document.getElementById(id);
        element.click();
    }
}

class Toolbox {
    Form = new FormUtil();
    Events = new EventsUtil();
}

var toolbox = new Toolbox();