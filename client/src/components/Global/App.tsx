import Header from './Header'
import { CssBaseline } from '@mui/material';
import { Outlet } from 'react-router';

function App() {

  return (
    <>
      <CssBaseline/>
      <Header />
      <Outlet/>
    </>
  )
}

export default App