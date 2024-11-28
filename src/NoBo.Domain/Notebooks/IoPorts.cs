namespace NoBo.Domain.Notebooks;

public record IOPorts(
    string Usb,
    string Hdmi,
    string Ethernet,
    string Audio
    );