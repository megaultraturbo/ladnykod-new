//import logo from './logo.svg';
import './App.css';
import { store } from './actions/store';
import { Provider } from 'react-redux';
import { Container } from '@mui/material';
import Books from './components/Books';
import BookForm from './components/BookForm';
import { ToastProvider } from 'react-toast-notifications';

function App() {
  return (
    <Provider store={store}>
      <ToastProvider autoDismiss={true}>
        <Container maxWidth="lg">
          <Books/>
        </Container>
      </ToastProvider>
    </Provider>
  );
}

export default App;
