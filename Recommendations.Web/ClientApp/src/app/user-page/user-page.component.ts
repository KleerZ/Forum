import {Component, OnInit} from "@angular/core";
import {ReviewsService} from "../../common/services/reviews/reviews.service";
import {ColumnMode} from '@swimlane/ngx-datatable';
import {ReviewUserPageModel} from "../../common/models/ReviewUserPageModel";
import {FormControl, FormGroup} from "@angular/forms";
import {FiltrationReviewService} from "../../common/services/filtration/filtration-review.service";
import {ActivatedRoute} from "@angular/router";
import {UserModel} from "../../common/models/UserModel";
import {UserService} from "../../common/services/user/user.service";
import {firstValueFrom} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {formToFormData} from "../../common/functions/formToFormData";
import {ImageService} from "../../common/services/images/image-service";

@Component({
  selector: 'app-user-page',
  templateUrl: 'user-page.component.html',
  styleUrls: ['user-page.component.css']
})
export class UserPageComponent implements OnInit {
  waiter: boolean = false
  ColumnMode = ColumnMode;
  reviews!: ReviewUserPageModel[]
  rows!: ReviewUserPageModel[]
  userData!: UserModel
  file!: File | undefined
  files?: File[] = []
  isNotImageChanged: boolean = true

  userId?: number | null = null
  currentUserId?: number

  constructor(public reviewsService: ReviewsService,
              private filtrationService: FiltrationReviewService,
              private activatedRoute: ActivatedRoute,
              private userService: UserService,
              private http: HttpClient,
              private imageService: ImageService) {

  }

  filterForm = new FormGroup({
    filterType: new FormControl(),
    filterValue: new FormControl()
  })

  async ngOnInit() {
    this.getUserIdFromQueryParams()
    await this.getAvatar()
    await this.getReviews()
    await this.getUserInfo(this.userId!)
  }

  async getUserInfo(userId?: number) {
    if (userId === undefined) {
      this.userData = await firstValueFrom(this.userService.getUserInfo())
      this.waiter = true
    } else {
      this.userData = await firstValueFrom(this.userService.getUserInfoById(userId))
      this.waiter = true
    }
  }

  async getReviews() {
    this.reviews = await firstValueFrom(this.reviewsService.getReviewsByUserId(this.userId))
    this.rows = this.reviews
  }

  deleteReview(reviewId: number) {
    this.rows = this.reviews.filter(review => review.reviewId !== reviewId.toString())
    this.reviews = this.rows
    this.reviewsService.deleteReview(reviewId)
      .subscribe({
        error: err => console.log(err)
      })
  }

  getUserIdFromQueryParams() {
    this.activatedRoute.params.subscribe({
      next: value => {
        this.userId = value['userid']
      }
    })
  }

  updateFilter() {
    let filterType: string = this.filterForm.get('filterType')?.value!
    let filterValue: string = this.filterForm.get('filterValue')?.value!

    this.rows = this.filtrationService.filtrateData(filterType, filterValue, this.reviews)
    console.log(this.rows)
  }

  resetFiltration() {
    this.rows = this.reviews
  }

  onSelectImage(event: any) {
    if (event.addedFiles[0] === undefined)
      return;

    this.file = <File>event.addedFiles[0]
    this.isNotImageChanged = false
    this.imageChangeForm.patchValue({image: this.file})
  }

  onRemoveImage(event: any) {
    this.file = undefined;
    this.isNotImageChanged = false
    this.imageChangeForm.patchValue({image: undefined})
  }

  imageChangeForm = new FormGroup({
    image: new FormControl()
  })

  sendImage() {
    this.http.post("api/user/change-avatar", formToFormData(this.imageChangeForm))
      .subscribe({})
  }

  async getAvatar() {
    if (this.userId !== undefined) {
      let userInfo = await firstValueFrom(this.userService.getUserInfoById(this.userId))
      if (userInfo.imageUrl !== null) {
        this.file = (await this.imageService.getImages([userInfo.imageUrl]))[0]
      }
    }
    else {
      let userInfo = await firstValueFrom(this.userService.getUserInfo())
      if (userInfo.imageUrl !== null) {
        this.file = (await this.imageService.getImages([userInfo.imageUrl]))[0]
      }
    }
  }

  async getCurrentUserId() {
    let currentUser = await firstValueFrom(this.userService.getUserInfo());
    this.currentUserId = currentUser.id
  }
}
