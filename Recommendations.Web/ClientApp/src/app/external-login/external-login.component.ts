import {Component} from '@angular/core';

@Component({
  selector: 'app-external-login',
  templateUrl: './external-login.component.html',
  styleUrls: ['external-login.component.css']
})
export class ExternalLoginComponent {
  externalAuth(provider: string) {
    window.location.href = `api/user/external-login?provider=${provider}`;
  }
}
