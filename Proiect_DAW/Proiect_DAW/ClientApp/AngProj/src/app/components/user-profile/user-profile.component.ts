import { Component,OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../services/user.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ReviewService } from '../../services/reviewService/review.service';
import { ShowHideDirective } from '../../directive/show-hide.directive';
import { SortPipe } from '../../pipe/sort.pipe';

@Component({
  selector: 'app-user-profile',
  templateUrl:'./user-profile.component.html',
  styleUrl:'./user-profile.component.css' 
})
export class UserProfileComponent {
  orders:string[]=[];
  username:string='';
  nrOfStars:number=0;
  description:string='';
  constructor(private route: ActivatedRoute,private reviewService:ReviewService, private userService: UserService) {}

  ngOnInit() {
    
    this.username = this.route.snapshot.params['username'];

    
    
     
      
    this.userService.getUserOrders(this.username).subscribe(
      (data:string[]) => {
        this.orders = data;
      },
      (error) => {
        console.error('Error fetching user details:', error);
      }
    );
    
      this.reviewService.getReviewByUserName(this.username).subscribe(
        (data)=>{
          this.nrOfStars=data.nrOfStars;
          this.description=data.description;
        },
        (error)=>{
          console.error;
        }
      )

  }
}
