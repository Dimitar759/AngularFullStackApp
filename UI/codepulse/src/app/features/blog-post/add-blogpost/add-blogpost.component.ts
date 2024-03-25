import { Component } from '@angular/core';
import { AddBlogPost } from '../models/add-blog-post.model';
import { log } from 'console';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrl: './add-blogpost.component.css'
})
export class AddBlogpostComponent {
  model:AddBlogPost;

  constructor(){
    this.model = {
      title: '',
      shortDescription: '',
      urlHandle: '',
      content: '',
      featuredImageUrl: '',
      author: '',
      isVisible: true,
      publishedDate: new Date(),
    }
  }

  onFormSubmit(): void{
    console.log(this.model);
  }
}
