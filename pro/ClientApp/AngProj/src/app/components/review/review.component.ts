import { Component ,OnInit} from '@angular/core';
import { ReviewService } from '../../services/reviewService/review.service';
import {  FormBuilder,FormGroup } from '@angular/forms';
import { UserService } from '../../services/user.service';
interface Star{
  value: number;
}

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrl: './review.component.css'
})
export class ReviewComponent implements OnInit{
  userId=localStorage.getItem('currentId');
  constructor(private reviewService: ReviewService,private userService:UserService,private fb:FormBuilder) {}
  rev!:FormGroup;
  message:string='';

  stars: Star[] = [
    {value: 0},
    {value: 1},
    {value: 2},
    {value: 3},
    {value: 4},
    {value: 5}
  ];

  ngOnInit(){
    this.rev=this.fb.group({
      nrOfStars:0,
      description:''
    })
    this.rev.valueChanges.subscribe(console.log)
  }
  addRev():void{
    const review={
      userId:this.userId,
      nrOfStars:this.rev.get('nrOfStars')?.value,
      description:this.rev.get('description')?.value
      
    };
    this.reviewService.addReview(review).subscribe(
      (data:string)=>{
        this.message=data;
        console.log(data);
      },
      (error)=>{
        console.error;
      }
    )
  }
  editRev():void{
    let starNumber=this.rev.get('nrOfStars')?.value;
    let desc=this.rev.get('description')?.value;
    if(this.userId){
      this.userService.updateUserReview(this.userId,starNumber,desc).subscribe(
        (data:string)=>{
          this.message=data;
          console.log(data);
        },
        (error)=>{
          console.error;
        }
      )
    }else{
      console.error();
    }
  }
}
