import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsviewComponent } from './components/products/productsview/productsview.component';
import { AuthGuard } from 'src/clients/auth_guard';

const routes: Routes = [
  {path: 'products', component:ProductsviewComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
