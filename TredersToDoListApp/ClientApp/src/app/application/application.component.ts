import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NavigationEnd, Router } from '@angular/router';
import { filter, Subscription } from 'rxjs';

@Component({
  selector: 'app-application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.css']
})
export class ApplicationComponent implements OnInit, OnDestroy {
  @ViewChild('sidenav') sidenav!: MatSidenav;

  private routeSubscription: Subscription | null = null;
  toolbarTitle: string = 'Aplikacja';
  availableOptions: string[] = [];
  showSidenavOptions = false;

  navigationItems: any = [] = [];

  constructor(private router: Router, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.showOptions();
    this.routeSubscription = this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe(() => {
      this.updateToolbar();
    });
  }

  ngOnDestroy(): void {
    if (this.routeSubscription) {
      this.routeSubscription.unsubscribe();
    }
  }

  updateToolbar() {
    const currentRoute = this.router.url;
    switch (currentRoute) {
      case '/application/home':
        this.toolbarTitle = 'Strona główna';
        break;
      case '/application/add':
        this.toolbarTitle = 'Dodaj zadanie';
        break;
        case '/application/edit':
        this.toolbarTitle = 'Lista zadań';
        break;
        case '/application/delete':
        this.toolbarTitle = 'Lista usuniętych zadań';
        break;
      default:
        this.toolbarTitle = 'Aplikacja';
    }
  }

  showOptions(): void {
    this.updateToolbar();
    this.navigationItems = [
      { title: 'Strona główna', icon: 'home', action: 'home' },
      { title: 'Dodaj zadanie', icon: 'add', action: 'add' },
      { title: 'Przejdź do listy zadań', icon: 'task', action: 'edit' },
      { title: 'Przejdź do listy zadań do usunięcia', icon: 'delete', action: 'delete' },
    ]
  }

  handleUserChoice(action: string): void {
    switch (action) {
      case 'home':
      case 'add':
      case 'edit':
      case 'delete':
        this.navigateTo(action);
        this.sidenav.close();
        break;
      default:
        this.exit();
    }
  }

  displaySuccessMessage(): void {
    this.snackBar.open('Sukces!', 'Zamknij', {
      duration: 3000,
      horizontalPosition: 'center',
      verticalPosition: 'bottom'
    });
  }

  showError(): void {
    this.snackBar.open('Błąd!', 'Zamknij', {
      duration: 3000,
      horizontalPosition: 'center',
      verticalPosition: 'bottom'
    });
  }

  private navigateTo(route: string) {
    this.router.navigate([`application/${route}`]);
  }

  exit(): void {
    if (confirm('Czy na pewno chcesz zamknąć aplikację?')) {
      window.location.href = 'about:blank';
    }
  }
}
