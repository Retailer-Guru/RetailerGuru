import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { tap } from "rxjs";
import { Observable } from "rxjs/internal/Observable";

@Injectable({
  providedIn: 'root'
})
export class GlobalService {

  constructor(private http: HttpClient) {

  }

  getObject<T>(apiExtension: string, /*errorMessage: Message, statusMessage?: Message*/): Observable<T> {
      let requestAddress = this.generateRequestAddress(apiExtension);
      return this.http.get<T>(requestAddress).pipe(
          tap(
              () => {
                  /*if(statusMessage != null && statusMessage != undefined)
                  {
                      //this.messageService.add(statusMessage);
                  }*/
              },
              (error: HttpErrorResponse) => {
                  /*if(errorMessage != null){
                      //this.messageService.add(errorMessage);
                      errorMessage.text += ' (Statuscode: ' + error?.status + ')';
                  }*/
                  console.log(error)
          })
      );
  }

  private generateRequestAddress(apiExtension : string) : string {
    const apiPath : string = "https://localhost:7097/api/v1-spa/" // TODO: in enviorment var verschieben
    if(apiPath.charAt(apiPath.length - 1) === '/'
        && apiExtension.charAt(0) === '/') {
        return apiPath.substr(0, apiPath.length - 1) + apiExtension;
    }
    else if(apiPath.charAt(apiPath.length - 1) !== '/'
        && apiExtension.charAt(0) !== '/') {
        return apiPath + '/' + apiExtension;
    }
    else {
        return apiPath + apiExtension;
    }
}
}
