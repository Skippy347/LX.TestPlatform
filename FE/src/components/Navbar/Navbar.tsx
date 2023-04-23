import { Box } from "@mui/material";
import styles from "./Navbar.module.scss";

export function Navbar() {
  return (
    <Box className={styles.header}>
      <Box className="container">
        <Box className={styles.header_inner}>
          <Box className={styles.header_logo}>Test Platform</Box>
          <button className={styles.header_btn} type="button">
            Sing In
          </button>
        </Box>
      </Box>
    </Box>
  );
}
