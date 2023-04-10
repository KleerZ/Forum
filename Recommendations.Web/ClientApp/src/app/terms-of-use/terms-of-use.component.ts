import {Component, Inject} from '@angular/core';
import {AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators} from "@angular/forms";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {UserService} from "../../common/services/user/user.service";

@Component({
  selector: 'app-terms',
  templateUrl: 'terms-of-use.component.html'
})
export class TermsOfUseComponent {

}
