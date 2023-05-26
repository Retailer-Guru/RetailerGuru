import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class GlobalService {

    constructor(private http: HttpClient) {

    }

    getObject<T>(apiExtension: string): Observable<T> {
        let requestAddress = this.generateRequestAddress(apiExtension);
        return this.http.get<T>(requestAddress);
    }

    putObject<T>(apiExtension: string, data: T){
        let requestAddress = this.generateRequestAddress(apiExtension);
        return this.http.put(requestAddress,
                            (JSON.stringify(data)),
                            {'headers': new HttpHeaders().set('Content-Type', 'application/json')})
    }

    postObject<T>(apiExtension: string, data: T){
        let requestAddress = this.generateRequestAddress(apiExtension);
        return this.http.post(requestAddress,
                             (JSON.stringify(data)),
                             {headers: new HttpHeaders().set('Content-Type', 'application/json')});
    }

    deleteObject<T>(apiExtension: string): Observable<T>{
        let requestAddress = this.generateRequestAddress(apiExtension);
        return this.http.delete<T>(requestAddress);
    }

    private generateRequestAddress(apiExtension : string) : string {
        let api = "https://localhost:7097";

        if(api.charAt(api.length - 1) === '/'
            && apiExtension.charAt(0) === '/') {
            return api.substr(0, api.length - 1) + apiExtension;
        }
        else if(api.charAt(api.length - 1) !== '/'
            && apiExtension.charAt(0) !== '/') {
            return api + '/' + apiExtension;
        }
        else {
            return api + apiExtension;
        }
    }
}
