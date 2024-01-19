import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './components/user/user.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { HomeComponent } from './components/home/home.component';
import { ItemComponent } from './components/item/item.component';
import { OrderComponent } from './components/order/order.component';
import { DistributorComponent } from './components/distributor/distributor.component';
import { ReviewComponent } from './components/review/review.component';
import { AuthGuardService } from './guard/auth-guard.service';
import { AdminComponent } from './components/admin/admin.component';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'user',canActivate:[AuthGuardService],component:UserComponent},
  {path:'user/:username',canActivate:[AuthGuardService],component:UserProfileComponent},
  {path:'item',canActivate:[AuthGuardService],component:ItemComponent},
  {path:'order/:Id',canActivate:[AuthGuardService],component:OrderComponent},
  {path:'distributor',canActivate:[AuthGuardService],component:DistributorComponent},
  {path:'review',canActivate:[AuthGuardService],component:ReviewComponent},
  {path:'admin',canActivate:[AuthGuardService],component:AdminComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
