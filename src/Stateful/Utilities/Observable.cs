using System;

namespace Stateful.Utilities {

	public interface IObservable {

		event Action<IObservable> Changed;
	}

	public class Observable<T> : IObservable {

		public delegate void ValueChangedHandler(Observable<T> observable, T previousValue, T newValue);
		public event ValueChangedHandler ValueChanged;
		public event Action<IObservable> Changed;

		private T value;
		public T Value {
			get => value;
			set {
				if (this.value.Equals(value)) {
					return;
				}
				T temp = this.value;
				this.value = value;
				ValueChanged?.Invoke(this, temp, this.value);
				Changed?.Invoke(this);
			}
		}

		public Observable() { }
		public Observable(T value) => this.value = value;
	}
}
