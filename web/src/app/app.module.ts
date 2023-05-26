import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ProductComponent } from './components/products/product/product.component';
import { ProductsviewComponent } from './components/products/productsview/productsview.component';
import { EditproductComponent } from './components/products/editproduct/editproduct.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './components/auth/login/login.component';
import { JwtModule } from '@auth0/angular-jwt';
import { NgApexchartsModule } from 'ng-apexcharts';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { BearerAuthInterceptor } from 'src/clients/bearerInterceptor';
import { SearchComponent } from './components/search/search.component';
import { StatistikviewComponent } from './components/statistiks/statistikview/statistikview.component';
import { DefaultbargraphComponent } from './components/statistiks/defaultbargraph/defaultbargraph.component';



export function tokenGetter(){
  return localStorage.getItem("jwt")
}

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    ProductsviewComponent,
    ProductComponent,
    EditproductComponent,
    LoginComponent,
    SearchComponent,
    StatistikviewComponent,
    DefaultbargraphComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgApexchartsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter
      }
    }),
    NgbModalModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: BearerAuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
