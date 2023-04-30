import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ProductComponent } from './components/products/product/product.component';
import { ProductsviewComponent } from './components/products/productsview/productsview.component';
import { EditproductComponent } from './components/products/editproduct/editproduct.component';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './components/auth/login/login.component';
import { JwtModule } from '@auth0/angular-jwt';

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
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
