import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsviewComponent } from './components/products/productsview/productsview.component';
import { AuthGuard } from 'src/clients/auth_guard';
import { AboutusComponent } from './components/aboutus/aboutus.component';
import { SearchComponent } from './components/search/search.component';

const routes: Routes = [
  {path: 'products', component:ProductsviewComponent, canActivate: [AuthGuard] },
  {path: 'aboutus', component:AboutusComponent,pathMatch:"full"},
  {path: 'search', component:SearchComponent, pathMatch:"full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
