import Header from './Header'
import { CssBaseline, ThemeProvider } from '@mui/material';
import { useState } from 'react';
import { Outlet } from 'react-router';
import lightTheme from './lightTheme';
import darkTheme from './darkTheme';

function App() {

  const [theme, setTheme] = useState(lightTheme);

  function toggleDarkMode() {
    if(theme.palette.mode === 'dark') {
      setTheme(lightTheme);
    } else {
      setTheme(darkTheme);
    }
  }


  return (
    <>
      <ThemeProvider theme={theme}>
        <CssBaseline/>
        <Header toggleDarkMode={toggleDarkMode} />
        <Outlet/>
      </ThemeProvider>
      
    </>
  )
}

export default App