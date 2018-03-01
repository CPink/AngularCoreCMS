import { PageService } from './../../services/page.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-pages',
  templateUrl: './pages.component.html',
  styleUrls: ['./pages.component.css']
})
export class PagesComponent implements OnInit {
  //properties
  private param: any;
  private pageBody: any;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private title: Title,
    private pageService: PageService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.param = params['page'];
      if (this.param === undefined) {
        this.param = 'home';
        this.title.setTitle('CoreCMS');
      } else {
        this.title.setTitle(this.param.replace(/-/g, ' ').replace(/\b\w/g, l => l.toUpperCase()));
      }
      this.pageService.getPage(this.param).subscribe(page => {
        if (page == "PageNotFound") {
          this.router.navigateByUrl('');
        }
        this.pageBody = page["content"];
      });
    });
  }

}
