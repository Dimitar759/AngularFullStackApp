import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-edit-blogpost',
  templateUrl: './edit-blogpost.component.html',
  styleUrl: './edit-blogpost.component.css'
})
export class EditBlogpostComponent implements OnInit, OnDestroy{
  id: string | null = null;
  routeSubscription?: Subscription;
  
  constructor(private route:ActivatedRoute){

  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params) =>{
        params.get('id');
      }
    });
  }

  ngOnDestroy(): void {
    
    this.routeSubscription?.unsubscribe();
  }

}
