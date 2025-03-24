import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgImageSliderModule } from 'ng-image-slider';
import { HttpClientModule } from '@angular/common/http';
import { PlantService } from '../services/plant.service';
import { FormsModule } from '@angular/forms';
import { debounceTime, distinctUntilChanged, Subject } from 'rxjs';


@Component({
  selector: 'app-homepage',
  imports: [CommonModule, NgImageSliderModule, HttpClientModule, FormsModule],
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css'],
  standalone: true
})
export class HomepageComponent implements OnInit {
  plantData: any[] = [];
  searchTerm: string = '';
  searchSubject: Subject<string> = new Subject();
  filteredPlants: any[] = [];
  listItems: any[] = [];

  showAvailabilityModal = false;
  selectedPlant: any = null;
  availableSlots: any[] = [];
  fromDate: string = '';
  toDate: string = '';

  constructor(private plantService: PlantService) {}

  ngOnInit(): void {
    this.fetchData();
    this.setupSearch();
  }

  fetchData(searchTerm: string = '') {
    this.plantService.getData(searchTerm).subscribe((result: any) => {
      console.log("Fetched Data:", result);
      this.plantData = result.data || [];
      this.filteredPlants = [...this.plantData];
      this.updateListItems();
    });
  }

  setupSearch() {
    this.searchSubject.pipe(debounceTime(300), distinctUntilChanged())
      .subscribe(term => this.fetchData(term));
  }

  onSearch(event: any) {
    this.searchTerm = event.target.value;
    this.searchSubject.next(this.searchTerm);
  }

  imageObject = [
    { image: 'assets/Banner Logo/banner1.jpeg', thumbImage: 'assets/Banner Logo/banner1.jpeg' },
    { image: 'assets/Banner Logo/banner2.jpeg', thumbImage: 'assets/Banner Logo/banner2.jpeg' },
    { image: 'assets/Banner Logo/banner3.jpeg', thumbImage: 'assets/Banner Logo/banner3.jpeg' }
  ];

  getPlantImage(plantId: number): string {
    const plantImageMap: { [key: number]: string } = {
      1: 'assets/Plant Logo/plant1.png',
      2: 'assets/Plant Logo/plant2.jpeg',
      3: 'assets/Plant Logo/plant3.jpeg',
      4: 'assets/Plant Logo/plant4.jpeg',
      5: 'assets/Plant Logo/plant5.jpeg',
    };
    return plantImageMap[plantId] || 'assets/Plant Logo/default.png';
  }

  updateListItems() {
    this.listItems = this.filteredPlants.map(plant => ({
      image: this.getPlantImage(plant.plantId)
    }));
  }

  showInstructionModal = false;
  selectedLanguage = 'english';

  handleButtonClick(button: string) {
    if (button === 'Instruction') {
      this.showInstructionModal = true;
    }
  }

  closeModal() {
    this.showInstructionModal = false;
  }

  selectLanguage(event: Event): void {
    const target = event.target as HTMLSelectElement;
    this.selectedLanguage = target.value;
    console.log('Selected language:', this.selectedLanguage);
  }

  onCheckAvailability(plant: any) {
    console.log('Availability Check for:', plant);
    this.selectedPlant = plant;
    this.showAvailabilityModal = true;

    this.availableSlots = [
      { date: '11 Mar 2025', day: 'Tuesday', time: '02:00 PM - 04:00 PM', availableVisits: 15 },
      { date: '12 Mar 2025', day: 'Wednesday', time: '02:00 PM - 04:00 PM', availableVisits: 61 },
      { date: '15 Mar 2025', day: 'Saturday', time: '02:00 PM - 04:00 PM', availableVisits: 188 },
      { date: '16 Mar 2025', day: 'Sunday', time: '02:00 PM - 04:00 PM', availableVisits: 157 }
    ];
  }

  closeAvailabilityModal() {
    this.showAvailabilityModal = false;
    this.selectedPlant = null;
  }

  bookVisit(slot: any) {
    console.log('Booking slot:', slot);
    alert(`Booking confirmed for ${slot.date}, ${slot.time}`);
  }
}
