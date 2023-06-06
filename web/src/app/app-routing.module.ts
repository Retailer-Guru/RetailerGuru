import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsviewComponent } from './components/products/productsview/productsview.component';
import { AuthGuard } from 'src/clients/auth_guard';
import { AboutusComponent } from './components/aboutus/aboutus.component';
import { SearchComponent } from './components/search/search.component';
import { StatistikviewComponent } from './components/statistiks/statistikview/statistikview.component';

const routes: Routes = [
  {path: 'products', component:ProductsviewComponent, canActivate: [AuthGuard] },
  {path: 'aboutus', component:AboutusComponent,pathMatch:"full"},
  {path: 'home', component:SearchComponent, pathMatch:"full"},
  {path: '', component:SearchComponent, pathMatch:"full"},
  {path: 'statisticsview/:productId', component:StatistikviewComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
