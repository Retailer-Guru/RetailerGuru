import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsviewComponent } from './components/products/productsview/productsview.component';

const routes: Routes = [
  {path: 'products', component:ProductsviewComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
