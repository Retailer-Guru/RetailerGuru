import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class BearerAuthInterceptor implements HttpInterceptor {
  constructor(){ }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const userToken = localStorage.getItem("jwt");

    req = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${userToken}`)
    });

    return next.handle(req);
  }
}
