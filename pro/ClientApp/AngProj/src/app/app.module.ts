import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { UserComponent } from './components/user/user.component';
import { UserService } from './services/user.service';
import { HttpClientModule } from '@angular/common/http';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { HomeComponent } from './components/home/home.component'; // Import HttpClientModule
import { ReactiveFormsModule } from '@angular/forms';

import{MatInputModule}from '@angular/material/input';
import{MatSelectModule}from '@angular/material/select';
import{MatButtonModule}from '@angular/material/button';
import {MatCheckboxModule}from  '@angular/material/checkbox';
import { MatChipsModule}from '@angular/material/chips';
import {MatIconModule} from '@angular/material/icon';
import {MatGridListModule} from '@angular/material/grid-list';
import { ItemComponent } from './components/item/item.component';
import { OrderComponent } from './components/order/order.component';
import { DistributorComponent } from './components/distributor/distributor.component';
import { ReviewComponent } from './components/review/review.component';
import { ShowHideDirective } from './directive/show-hide.directive';
import { SortPipe } from './pipe/sort.pipe';
import { OrderService } from './services/orderService/order.service';
import { ItemService } from './services/itemService/item.service';
import { ReviewService } from './services/reviewService/review.service';
import { DistributorService } from './services/distributorService/distributor.service';
import { AuthGuardService } from './guard/auth-guard.service';
import { AdminComponent } from './components/admin/admin.component';



@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    UserProfileComponent,
    HomeComponent,
    ItemComponent,
    OrderComponent,
    DistributorComponent,
    ReviewComponent,
    ShowHideDirective,
    SortPipe,
    AdminComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatCheckboxModule,
    MatChipsModule,
    MatIconModule,
    MatGridListModule
  ],
  providers: [
    UserService,
    OrderService,
    ItemService,
    ReviewService,
    DistributorService,
    AuthGuardService

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
