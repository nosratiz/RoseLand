
export function AjaxRequest(url, method, data) {
    return $.ajax({
        url: url,
        type: method,
        dataType: "json",
        contentType: "application/json",
        //contentType:"application/json",
        data: data
    });
}