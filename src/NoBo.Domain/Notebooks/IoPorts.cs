namespace NoBo.Domain.Notebooks;

public record IoPorts(
    string Usb,
    string Hdmi,
    string Ethernet,
    string Audio
    );